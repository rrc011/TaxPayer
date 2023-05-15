import React from 'react'
import { Board, Empty, PageTitle } from '../../../shared/components'
import { Button, Table } from 'react-bootstrap'
import { useNavigate, useParams } from 'react-router-dom'
import TaxReceiptService from '../../../services/taxreceipt.service'
import { CreateTaxReceipt } from './CreateTaxReceipt'

export const TaxReceiptPage = () => {
    const navigate = useNavigate()
    const params = useParams();
    const taxPayerId = params.id!
    const PAGE_NUMBER = 1;
    const PAGE_SIZE = 10;
    const [data, setData] = React.useState<any>(null);
    const [taxPayer, setTaxPayer] = React.useState<any>([]);
    const [pageConfig, setPageConfig] = React.useState<any>({
        currentPage: PAGE_NUMBER,
        pageSize: PAGE_SIZE,
        totalCount: 0,
    });
    const [showCreateOrEditModal, setShowCreateOrEditModal] = React.useState<boolean>(false);

    const goBack = () => {
        navigate(-1)
    }

    React.useEffect(() => {
        fetchData(pageConfig.currentPage);
    }, [pageConfig.currentPage]);

    const fetchData = async (pageNumber: number) => {
        try {
            const { data } = await TaxReceiptService.GetTaxReceipts({
                pageNumber,
                pageSize: 10,
                taxPayerId
            });
            setPageConfig({
                currentPage: data.currentPage,
                pageSize: data.pageSize,
                totalCount: data.totalCount,
            })
            const payer = data.data[0].taxPayer;
            setData(data.data);
            if (payer) {
                setTaxPayer([
                    {
                        label: 'Nombre del contribuyente:',
                        icon: 'fas fa-calendar-edit',
                        cols: 'col-md-3 pt-2',
                        data: payer.name,
                    },
                    {
                        label: 'Tipo:',
                        icon: 'fas fa-calendar-edit',
                        cols: 'col-md-3 pt-2',
                        data: payer.typeDescription,
                    },
                    {
                        label: 'Estado:',
                        icon: 'fas fa-calendar-edit',
                        cols: 'col-md-3 pt-2',
                        data: payer.statusDescription,
                    },
                    {
                        label: 'RNC:',
                        icon: 'fas fa-calendar-edit',
                        cols: 'col-md-3 pt-2',
                        data: payer.rnc,
                    }
                ]);
            }
        } catch (error) {
            console.error(error);
        }
    };

    const formattedPrice = (price: number) => price.toLocaleString('es-DO', { style: 'currency', currency: 'DOP' });

    return (
        <>
            <PageTitle title='Comprobantes Fiscales'>
                <Button className='mx-2' variant="outline-secondary" style={{ height: 'fit-content' }} onClick={goBack}>Regresar</Button>
                <Button variant="outline-primary" style={{ height: 'fit-content' }} onClick={() => setShowCreateOrEditModal(true)}>Crear</Button>
            </PageTitle>

            {taxPayer && <Board details={taxPayer} />}

            {data && data.length === 0 ? <Empty /> : <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>NFC</th>
                        <th>Monto</th>
                        <th>Itbis</th>
                    </tr>
                </thead>
                <tbody>
                    {data && data.map((item: any, index: number) => {
                        return (<>
                            <tr key={item.id}>
                                <td>{index + 1}</td>
                                <td>{item.ncf}</td>
                                <td>{formattedPrice(item.amount)}</td>
                                <td>{formattedPrice(item.tax)}</td>
                            </tr>
                        </>)
                    })
                    }
                </tbody>
                {data && <tfoot>
                    <tr>
                        <td></td>
                        <td></td>
                        <td className='fw-bold'>{formattedPrice(data?.reduce((acc: number, item: any) => acc + item.amount, 0))}</td>
                        <td className='fw-bold'>{formattedPrice(data?.reduce((acc: number, item: any) => acc + item.tax, 0))}</td>
                    </tr>
                </tfoot>}
            </Table>}
            <CreateTaxReceipt show={showCreateOrEditModal} setShow={setShowCreateOrEditModal} reload={() => fetchData(PAGE_NUMBER)} />
        </>
    )
}
