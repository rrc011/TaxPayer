import clsx from 'clsx'
import React from 'react'

const Board: React.FC<{ details: any[] }> = ({ details }) => {
    return (
        <>
            <div className='bg-secondary-1 rounded py-2 px-1 mb-3'>
                <div className='row mx-1 bg-white board-radius p-2'>
                    {details && details.map((item) => {
                        return (
                            <div className={clsx({
                                'col-sm w-50': Boolean(item.cols) == false,
                                [`${item.cols}`]: Boolean(item.cols),
                            })} key={item.label}>
                                <div className='flex'>
                                    <i className={clsx(`pt-1 mr-2 ${item.icon}`)} aria-hidden="true"></i>
                                    <div>
                                        <span className='fs-5 text-dark'>{item.label}</span>
                                        <p>{item.data}</p>
                                    </div>
                                </div>
                            </div>
                        )
                    })}
                </div>

            </div>
        </>
    )
}

export default Board
