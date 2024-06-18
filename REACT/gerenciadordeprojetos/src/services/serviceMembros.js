import instace from "../helpers/api"

export async function GetMembros(){
    return await instace.get(`/Membros`)
}

export async function GetMembrosById(id){
    return await instace.get(`/Membros/GetMembrosById/${id}`)
}
