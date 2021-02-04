
export interface ImportationListModel {
    id?;
    name?;
    deliveryDate?;
    quantity?;
    totalValue?;
  }
  
  export interface ImportationDetailsModel {
    name?;
    deliveryDate?;
    quantity?;
    unitValue?;
    totalValue?;
  }
  
  export class ImportationListModel{
    constructor(
        public id?,
        public name?,
        public deliveryDate?,
        public quantity?,
        public totalValue?
    ){  }
  
    static fromJson(jsonData: any): ImportationListModel {
        return Object.assign(new ImportationListModel(), jsonData);
    }
  }
  
  export class ImportationDetailsModel{
    constructor(
        public name?,
        public deliveryDate?,
        public quantity?,
        public unitValue?,
        public totalValue?
    ){  }
    
    static fromJson(jsonData: any): ImportationDetailsModel {
        return Object.assign(new ImportationDetailsModel(), jsonData);
    }
  }
  