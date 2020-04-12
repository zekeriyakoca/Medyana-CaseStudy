interface PaginatedList<T>{
    items:T[],
    hasNext:boolean,
    hasPrev:boolean,
    page:number,
    totalPage:number,
    totalItemCount:number

}