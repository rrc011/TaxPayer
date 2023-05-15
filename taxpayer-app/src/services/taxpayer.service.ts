import { AxiosRequestConfig } from "axios";
import { ApiResponse, BaseService } from "./base.service";
import { BASE_API_URL } from "../constants/contanst";
import { ResultDto } from "../models/ResultDto";

class TaxPayerService extends BaseService {
    constructor() {
        super(BASE_API_URL);
    }

    public async GetTaxPayer(data: any) {
        const config: AxiosRequestConfig = {
            method: 'GET',
            url: 'TaxPayer',
            params: {
                ...data,
            },
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }


    public async AddTaxPayer(data: any) {
        const config: AxiosRequestConfig = {
            method: 'POST',
            url: 'TaxPayer',
            data
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }


    public async UpdateTaxPayer(data: any) {
        const config: AxiosRequestConfig = {
            method: 'PUT',
            url: 'TaxPayer',
            data
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }


    public async DeleteTaxPayer(id: number) {
        const config: AxiosRequestConfig = {
            method: 'DELETE',
            url: 'TaxPayer',
            data: {
                id
            }
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }
}

export default new TaxPayerService();