import axios, { AxiosInstance, AxiosRequestConfig, AxiosResponse } from 'axios';

export interface ApiResponse<T> {
  data: T;
}

export class BaseService {
  protected axiosInstance: AxiosInstance;

  constructor(baseURL: string) {
    this.axiosInstance = axios.create({
      baseURL,
    });

    // Agrega aquí cualquier configuración adicional que necesites, como encabezados personalizados, interceptores, etc.
    this.axiosInstance.interceptors.request.use(
      (config: any) => {
        document.body.classList.add('loading-indicator')
        return config
      },
      (err: any) => {
        document.body.classList.remove('loading-indicator')
        Promise.reject(err)
      }
    );
    this.axiosInstance.interceptors.response.use(
      (config: any) => {
        document.body.classList.remove('loading-indicator')
        return config
      },
      (err: any) => {
        document.body.classList.remove('loading-indicator')
        Promise.reject(err)
      }
    );
  }

  // Método genérico para realizar una solicitud a la API
  protected async request<T>(config: AxiosRequestConfig): Promise<ApiResponse<T>> {
    const response: AxiosResponse<T> = await this.axiosInstance.request<T>(config).catch((error) => {
      throw error;
    });
    const apiResponse: ApiResponse<T> = {
      data: response.data,
    };

    return apiResponse;
  }
}