import React from 'react';
import { Pagination } from 'react-bootstrap';

const CustomPagination: React.FC<{ currentPage: number, pageSize: number, totalCount: number, onPageChange: any }> =
  ({ currentPage, pageSize, totalCount, onPageChange }) => {
    const totalPages = Math.ceil(totalCount / pageSize);

    const handlePageChange = (page: number) => {
      if (onPageChange) {
        onPageChange(page);
      }
    };

    return (
      <Pagination>
        <Pagination.First onClick={() => handlePageChange(1)} />
        <Pagination.Prev onClick={() => handlePageChange(currentPage - 1)} />

        {currentPage > 2 && (
          <>
            <Pagination.Item onClick={() => handlePageChange(1)}>{1}</Pagination.Item>
            {currentPage > 3 && <Pagination.Ellipsis />}
          </>
        )}

        {currentPage > 1 && (
          <Pagination.Item onClick={() => handlePageChange(currentPage - 1)}>{currentPage - 1}</Pagination.Item>
        )}

        <Pagination.Item active>{currentPage}</Pagination.Item>

        {currentPage < totalPages && (
          <Pagination.Item onClick={() => handlePageChange(currentPage + 1)}>{currentPage + 1}</Pagination.Item>
        )}

        {(currentPage < totalPages - 1) && (
          <>
            {currentPage < totalPages - 2 && <Pagination.Ellipsis />}
            <Pagination.Item onClick={() => handlePageChange(totalPages)}>{totalPages}</Pagination.Item>
          </>
        )}

        <Pagination.Next onClick={() => handlePageChange(currentPage + 1)} />
        <Pagination.Last onClick={() => handlePageChange(totalPages)} />
      </Pagination>
    );
  };

export default CustomPagination;