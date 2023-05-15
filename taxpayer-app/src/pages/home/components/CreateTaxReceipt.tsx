import React from 'react'
import * as Yup from 'yup'
import { useFormik } from 'formik'
import { clsx } from 'clsx';
import { Button, Modal } from 'react-bootstrap'
import TaxReceiptService from '../../../services/taxreceipt.service'
import { useParams } from 'react-router-dom';


const schema = Yup.object().shape({
    amount: Yup.number()
        .min(1, 'Debe ser mayor a 0')
        .required('El monto es requerido')
})

export const CreateTaxReceipt: React.FC<{ show: boolean, setShow: any, reload: any }> = ({ show, setShow, reload }) => {
    const params = useParams();
    const taxPayerId = params.id!

    const generateRandomNumber = () => {
        const min = Math.pow(10, 10);
        const max = Math.pow(10, 11) - 1;
        return Math.floor(Math.random() * (max - min + 1) + min);
    }

    const closeModal = () => {
        setShow(false)
        formik.resetForm()
    }

    const formik = useFormik({
        initialValues: {
            amount: 0,
        } as any,
        validationSchema: schema,
        onSubmit: async (values) => {

            const { data } = await TaxReceiptService.AddTaxReceipt({
                ...values,
                taxPayerId,
                ncf: 'E' + generateRandomNumber()
            });
            if (data.succeeded) {
                closeModal()
                reload();
            }
        },
    })

    return (
        <>
            <Modal
                size="lg"
                show={show}
                onHide={() => setShow(false)}
                aria-labelledby="example-modal-sizes-title-sm"
            >
                <Modal.Header closeButton>
                    <Modal.Title id="example-modal-sizes-title-sm">
                        Nuevo
                    </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                    <form className="row g-3 needs-validation" noValidate>
                        <div className="col-12">
                            <label htmlFor="validationCustom01" className="form-label">
                                Monto
                            </label>
                            <input
                                type="number"
                                min={1}
                                autoComplete='off'
                                {...formik.getFieldProps('amount')}
                                className={clsx(
                                    'form-control',
                                    {
                                        'is-invalid': formik.touched.amount && formik.errors.amount,
                                    },
                                    {
                                        'is-valid': formik.touched.amount && !formik.errors.amount,
                                    }
                                )}
                            />
                            {formik.errors.amount && typeof formik.errors.amount === 'string' && (
                                <div className='text-danger mt-2'>{formik.errors.amount}</div>
                            )}
                        </div>
                    </form>

                </Modal.Body>
                <Modal.Footer>
                    <Button variant="secondary" onClick={closeModal}>
                        Cerrar
                    </Button>
                    <Button variant="primary" onClick={() => formik.handleSubmit()}>
                        Guardar
                    </Button>
                </Modal.Footer>
            </Modal>
        </>
    )
}

