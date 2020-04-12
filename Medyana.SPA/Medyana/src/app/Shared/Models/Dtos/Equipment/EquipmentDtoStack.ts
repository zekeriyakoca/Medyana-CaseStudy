interface Equipment {
    id: number;
    name: string;
    supplyDate: Date;
    quantity:number;
    usageRate:number;
    price:number;
    clinicId:number;
    clinic:Clinic;
}

interface EquipmentUpdateRequest {
    id: number;
    name: string;
    quantity:number;
    usageRate:number;
    price:number;
    clinicId:number;
}

interface EquipmentInsertRequest {
    name: string;
    quantity:number;
    usageRate:number;
    price:number;
    clinicId:number;
}