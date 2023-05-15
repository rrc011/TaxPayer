import React, { ReactNode } from 'react'

const PageTitle: React.FC<{ title: string, children: ReactNode }> = ({ title, children }) => {
    return (
        <>
            <div className="row">
                <div className="col-md-12 d-flex justify-content-between pb-4">
                    <h1>{title}</h1>
                    <div className='d-flex'>
                        {children}
                    </div>
                </div>
            </div>
        </>
    )
}

export default PageTitle
