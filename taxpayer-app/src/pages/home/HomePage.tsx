import React from 'react';
import Table from 'react-bootstrap/Table';
import Dropdown from 'react-bootstrap/Dropdown';
import DropdownButton from 'react-bootstrap/DropdownButton';
import { clsx } from 'clsx';
import { Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';
import TaxPayerService from '../../services/taxpayer.service';
import { CustomPagination, PageTitle } from '../../shared/components';
import { CreateOrEditTaxPayer } from './components/CreateOrEditTaxPayer';
import { alertService } from '../../shared/alertService';

const HomePage: React.FC = () => {
  const PAGE_NUMBER = 1;
  const PAGE_SIZE = 10;
  const [data, setData] = React.useState<any>(null);
  const [pageConfig, setPageConfig] = React.useState<any>({
    currentPage: PAGE_NUMBER,
    pageSize: PAGE_SIZE,
    totalCount: 0,
  });
  const [showCreateOrEditModal, setShowCreateOrEditModal] = React.useState<boolean>(false);
  const [currentRow, setCurrentRow] = React.useState<any>(null);
  const navigate = useNavigate()

  React.useEffect(() => {
    fetchData(pageConfig.currentPage);
  }, [pageConfig.currentPage]);

  const fetchData = async (pageNumber: number) => {
    try {
      const { data } = await TaxPayerService.GetTaxPayer({
        pageNumber,
        pageSize: pageConfig.pageSize,
      });
      setPageConfig({
        currentPage: data.currentPage,
        pageSize: data.pageSize,
        totalCount: data.totalCount,
      })
      setData(data.data);
    } catch (error) {
      console.error(error);
    }
  };

  const deleteTaxPayer = async (item: any) => {
    alertService.confirm(async () => {
      const { data } = await TaxPayerService.DeleteTaxPayer(
        item.id
      );
      if (data.succeeded) {
        fetchData(PAGE_NUMBER)
        alertService.success('Contribuyente eliminado correctamente')
      }
    }, `¿Esta seguro que desea eliminar el contribuyente ${item.name}?`)
  }

  const goToDetails = (payer: any) => {
    navigate(`/taxes/${payer.id}`)
  }

  const editRow = (payer: any) => {
    setCurrentRow(payer);
    setShowCreateOrEditModal(true);
  }

  return (
    <>
      <PageTitle title='Contribuyentes'>
        <Button variant="outline-primary" style={{ height: 'fit-content' }} onClick={() => setShowCreateOrEditModal(true)}>Crear</Button>
      </PageTitle>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>#</th>
            <th>RNC / Cedula</th>
            <th>Nombre</th>
            <th>Tipo</th>
            <th>Estatus</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {data && data.map((item: any, index: number) => {
            return (<>
              <tr key={item.id}>
                <td>{index + 1}</td>
                <td>{item.rnc}</td>
                <td>{item.name}</td>
                <td>{item.typeDescription}</td>
                <td>
                  <span className={clsx('badge',
                    {
                      'text-bg-success': item.status === 1,
                    },
                    {
                      'text-bg-warning': item.status === 2,
                    },
                  )}>{item.statusDescription}</span>
                </td>
                <td className='d-flex justify-content-center'>
                  <DropdownButton id="dropdown-basic-button" title="Opciones">
                    <Dropdown.Item onClick={() => goToDetails(item)}>Ver</Dropdown.Item>
                    <Dropdown.Item onClick={() => editRow(item)}>Editar</Dropdown.Item>
                    <Dropdown.Item onClick={() => deleteTaxPayer(item)}>Eliminar</Dropdown.Item>
                  </DropdownButton>
                </td>
              </tr>
            </>)
          })
          }
        </tbody>
      </Table>
      <div className='d-flex justify-content-center'>
        <CustomPagination currentPage={pageConfig.currentPage} pageSize={pageConfig.pageSize} totalCount={pageConfig.totalCount} onPageChange={fetchData} />
      </div>
      <CreateOrEditTaxPayer show={showCreateOrEditModal} setShow={setShowCreateOrEditModal} reload={() => fetchData(PAGE_NUMBER)}
        payload={currentRow} setPayload={setCurrentRow} />
    </>
  )
}

export { HomePage }