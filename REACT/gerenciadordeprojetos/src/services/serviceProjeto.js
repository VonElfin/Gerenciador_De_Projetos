import Api from "../helpers/api";

export async function GetProjeto(){
    return await Api.get(`Projeto`);
}

export async function GetProjetoById(id){
    return await Api.get(`/Projeto/GetProjetoById/${id}`);
}

export async function PostProjeto(projeto){
    return await Api.post(`/Projeto/PostProjeto`, projeto)
}

export async function PutProjeto(projeto){
    return await Api.put("/Projeto/PutProjeto", projeto);
 }

 export async function DeleteProjeto(id){
    return await Api.delete(`/Projeto/DeleteProjeto/${id}`)
 }