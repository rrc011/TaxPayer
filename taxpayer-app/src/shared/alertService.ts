import Swal from 'sweetalert2';
import 'sweetalert2/dist/sweetalert2.css';

export const alertService = {
    success: (message: string) => {
        Swal.fire({
            title: 'Éxito',
            text: message,
            icon: 'success',
            confirmButtonText: 'OK',
        });
    },

    error: (message: string) => {
        Swal.fire({
            title: 'Error',
            text: message,
            icon: 'error',
            confirmButtonText: 'OK',
        });
    },

    confirm: (onConfirmed: () => void, message: string, title?: string): Promise<any> => {
        return Swal.fire({
            title: title || 'Estás seguro?',
            text: message,
            icon: 'question',
            showCancelButton: true,
            confirmButtonText: 'Sí, guardar!',
            cancelButtonText: 'No, cancelar!',
        }).then((result) => {
            if (result.isConfirmed) {
                onConfirmed();
            }
            return result;
        });
    },
};