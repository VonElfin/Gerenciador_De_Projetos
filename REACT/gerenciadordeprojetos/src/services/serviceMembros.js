import Api from "../helpers/api"

export async function GetMembros(){
    return await Api.get(`/Membros`)
}

export async function GetMembrosById(id){
    return await Api.get(`/Membros/GetMembrosById/${id}`);
}
 export async function PostMembros(membros){
    return await Api.post("/Membros/PostMembros", membros);
 }

 export async function PutMembros(membros){
    return await Api.put("/Membros/PutMembros", membros);
 }

 export async function DeleteMembro(id){
    return await Api.delete(`/Membros/DeleteMembro/${id}`)
 }