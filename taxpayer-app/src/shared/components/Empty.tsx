import React from 'react';

const Empty: React.FC<{ message?: string }> = ({ message }) => {
    return (
        <div className="text-center mt-4">
            <div className="row">
                <div className="col-12">
                    <svg width="76px" height="76px" viewBox="0 0 14 14" role="img" focusable="false" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" stroke-width="0"></g><g id="SVGRepo_tracerCarrier" stroke-linecap="round" stroke-linejoin="round"></g><g id="SVGRepo_iconCarrier"><path fill="#c9c9c9" d="M10.67276443 3.58608316H6.12087531L4.98290303 2.44811088h-2.8449307c-.62588475 0-1.13797228.51208753-1.13797228 1.13797228v6.82783368c0 .62588475.51208753 1.13797228 1.13797228 1.13797228h8.81928517c.48363822 0 .85347921-.369841.85347921-.85347921V4.72405544c0-.62588475-.51208753-1.13797228-1.13797228-1.13797228z"></path><path fill="#a8a8a8" d="M11.86763532 5.29304158H4.21477174c-.54053683 0-1.02417505.3982903-1.10952297.93882713l-.96727644 5.32002041h9.01843032c.54053683 0 1.02417505-.3982903 1.10952297-.93882713L12.9771583 6.630159c.14224653-.68278337-.3982903-1.33711743-1.10952298-1.33711743z"></path></g></svg>
                </div>
                <div className="col-12 mt-2">
                    <span className="text-lg font-bold text-secondary tracking-normal">
                        {message || 'No hay información disponible.'}
                    </span>
                </div>
            </div>
        </div>
    );
};

export default Empty;