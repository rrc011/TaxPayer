/* eslint-disable no-prototype-builtins */
/* eslint-disable @typescript-eslint/no-explicit-any */
export interface IResultAPI {
    data: any | undefined;
    currentPage: number | undefined;
    totalPages: number | undefined;
    totalCount: number | undefined;
    pageSize: number | undefined;
    hasPreviousPage: boolean | undefined;
    hasNextPage: boolean | undefined;
    messages: null | undefined;
    succeeded: boolean | undefined;
    code: number | undefined;
}

export class ResultDto implements IResultAPI {
    data: any | undefined;
    currentPage: number | undefined;
    totalPages: number | undefined;
    totalCount: number | undefined;
    pageSize: number | undefined;
    hasPreviousPage: boolean | undefined;
    hasNextPage: boolean | undefined;
    messages: null | undefined;
    succeeded: boolean | undefined;
    code: number | undefined;


    constructor(data?: IResultAPI) {
        if (data) {
            for (const property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(data?: any) {
        if (data) {
            this.data = data['data']
            this.currentPage = data['currentPage']
            this.totalPages = data['totalPages']
            this.totalCount = data['totalCount']
            this.pageSize = data['pageSize']
            this.hasPreviousPage = data['hasPreviousPage']
            this.hasNextPage = data['hasNextPage']
            this.messages = data['messages']
            this.succeeded = data['succeeded']
            this.code = data['code']
        }
    }

    static fromJS(data: any): ResultDto {
        data = typeof data === 'object' ? data : {};
        const result = new ResultDto();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data['data'] = this.data
        data['currentPage'] = this.currentPage
        data['totalPages'] = this.totalPages
        data['totalCount'] = this.totalCount
        data['pageSize'] = this.pageSize
        data['hasPreviousPage'] = this.hasPreviousPage
        data['hasNextPage'] = this.hasNextPage
        data['messages'] = this.messages
        data['succeeded'] = this.succeeded
        data['code'] = this.code
        return data;
    }

    clone(): ResultDto {
        const json = this.toJSON();
        const result = new ResultDto();
        result.init(json);
        return result;
    }
}