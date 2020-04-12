interface PaginationRequest {

    page: number,
    pageItemCount: number,
    searchText?: string,
    isAscending?: boolean,
    column?: string,
    clinicId?: number,
}