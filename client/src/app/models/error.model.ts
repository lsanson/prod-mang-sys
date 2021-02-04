export interface ImportationError {
    property?: string
    message?: string
}

export class ImportationError{
    constructor(
        public property?: string,
        public message?: string
    ){  }
    
    static fromJson(jsonData: any): ImportationError {
        return Object.assign(new ImportationError(), jsonData);
    }
}