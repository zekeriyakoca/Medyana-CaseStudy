interface Clinic {
    id: number;
    name: string;
    equipments?: Equipment[];
}

interface ClinicUpdateRequest {
    id: number;
    name: string;
}

interface ClinicInsertRequest {
    name: string;
}