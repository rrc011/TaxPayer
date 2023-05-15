import { AxiosRequestConfig } from "axios";
import { ApiResponse, BaseService } from "./base.service";
import { BASE_API_URL } from "../constants/contanst";
import { ResultDto } from "../models/ResultDto";

class TaxReceiptService extends BaseService {
    constructor() {
        super(BASE_API_URL);
    }

    public async GetTaxReceipts(data: any) {
        const config: AxiosRequestConfig = {
            method: 'GET',
            url: 'TaxReceipt',
            params: {
                ...data,
            },
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }

    //add tax payer
    public async AddTaxReceipt(data: any) {
        const config: AxiosRequestConfig = {
            method: 'POST',
            url: 'TaxReceipt',
            data: data
        };

        const response: ApiResponse<ResultDto> = await this.request<any>(config);
        return response;
    }
}

export default new TaxReceiptService();