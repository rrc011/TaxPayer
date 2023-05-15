import React from 'react'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import { clsx } from 'clsx';
import { Button, Modal } from 'react-bootstrap'
import TaxPayerService from '../../../services/taxpayer.service';
import { alertService } from '../../../shared/alertService';


const schema = Yup.object().shape({
    name: Yup.string()
        .min(6, 'Minimo 6 caracteres')
        .max(100, 'Maximo 50 caracteres')
        .required('El nombre es requerido'),
    type: Yup.string().nullable()
        .required('El tipo es requerido'),
    status: Yup.string().nullable()
})

export const CreateOrEditTaxPayer: React.FC<{ show: boolean, setShow: any, reload: any, payload?: any, setPayload: any }> =
    ({ show, setShow, reload, payload, setPayload }) => {

        React.useEffect(() => {
            if (payload) {
                formik.setValues({
                    ...formik.values,
                    name: payload?.name,
                    type: payload?.type,
                    status: payload?.status
                })
            }
            // eslint-disable-next-line react-hooks/exhaustive-deps
        }, [payload])

        const generateRandomNumber = () => {
            const min = Math.pow(10, 10);
            const max = Math.pow(10, 11) - 1;
            return Math.floor(Math.random() * (max - min + 1) + min);
        }

        const closeModal = () => {
            setShow(false)
            setPayload(null)
            formik.resetForm()
        }

        const formik = useFormik({
            initialValues: {
                name: '',
                type: undefined,
                status: undefined
            } as any,
            validationSchema: schema,
            onSubmit: async (values) => {
                if (payload) {
                    alertService.confirm(async () => {
                        const { data } = await TaxPayerService.UpdateTaxPayer({
                            ...values,
                            status: parseInt(values.status),
                            Id: payload.id
                        });
                        if (data.succeeded) {
                            closeModal()
                            reload();
                            alertService.success('Contribuyente editado correctamente')
                        }
                    }, 'Esta seguro que desea editar este contribuyente?')
                } else {
                    alertService.confirm(async () => {
                        const { data } = await TaxPayerService.AddTaxPayer({
                            ...values,
                            status: 1,
                            rnc: '' + generateRandomNumber()
                        });
                        if (data.succeeded) {
                            closeModal()
                            reload();
                            alertService.success('Contribuyente creado correctamente')
                        }
                    }, 'Esta seguro que desea crear este contribuyente?')
                }
            },
        })

        return (
            <>
                <Modal
                    size="lg"
                    show={show}
                    onHide={closeModal}
                    aria-labelledby="example-modal-sizes-title-sm"
                >
                    <Modal.Header closeButton>
                        <Modal.Title id="example-modal-sizes-title-sm">
                            {payload ? payload.name : 'Nuevo'}
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <form className="row g-3 needs-validation" noValidate>
                            <div className="col-12">
                                <label htmlFor="validationCustom01" className="form-label">
                                    Nombre de la empresa o persona
                                </label>
                                <input
                                    type="text"
                                    autoComplete='off'
                                    {...formik.getFieldProps('name')}
                                    className={clsx(
                                        'form-control',
                                        {
                                            'is-invalid': formik.touched.name && formik.errors.name,
                                        },
                                        {
                                            'is-valid': formik.touched.name && !formik.errors.name,
                                        }
                                    )}
                                />
                                {formik.errors.name && typeof formik.errors.name === 'string' && (
                                    <div className='text-danger mt-2'>{formik.errors.name}</div>
                                )}
                            </div>
                            <div className="col-12">
                                <label htmlFor="validationCustom02" className="form-label">
                                    Tipo de contribuyente
                                </label>
                                <select {...formik.getFieldProps('type')} className={clsx(
                                    'form-select',
                                    {
                                        'is-invalid': formik.touched.type && formik.errors.type,
                                    },
                                    {
                                        'is-valid': formik.touched.type && !formik.errors.type,
                                    }
                                )}>
                                    <option selected>Seleccione</option>
                                    <option value="1">Persona Fisica</option>
                                    <option value="2">Personas Jurídica</option>
                                </select>
                                {formik.errors.type && typeof formik.errors.type === 'string' && (
                                    <div className='text-danger mt-2'>{formik.errors.type}</div>
                                )}
                            </div>
                            {payload && <div className="col-12">
                                <label htmlFor="validationCustom02" className="form-label">
                                    Estatus
                                </label>
                                <select {...formik.getFieldProps('status')} className={clsx(
                                    'form-select',
                                    {
                                        'is-invalid': formik.touched.status && formik.errors.status,
                                    },
                                    {
                                        'is-valid': formik.touched.status && !formik.errors.status,
                                    }
                                )}>
                                    <option value="1">Activo</option>
                                    <option value="2">Inactivo</option>
                                </select>
                            </div>}
                        </form>

                    </Modal.Body>
                    <Modal.Footer>
                        <Button variant="secondary" onClick={closeModal}>
                            Cerrar
                        </Button>
                        <Button variant="primary" onClick={() => formik.handleSubmit()}>
                            {payload ? 'Editar' : 'Guardar'}
                        </Button>
                    </Modal.Footer>
                </Modal>
            </>
        )
    }
