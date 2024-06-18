import Api from "../helpers/api"

export async function GetMembros(){
    return await Api.get(`/Membros`)
}

export async function GetMembrosById(id){
    return await Api.get(`/Membros/GetMembrosById/${id}`)
}
