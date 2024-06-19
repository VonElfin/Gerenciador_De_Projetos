import Api from "../helpers/api";

export async function GetTarefa(){
    return await Api.get(`/Tarefa`)
}

export async function GetTarefaById(id){
    return await Api.get(`/Tarefa/GetTarefaById/${id}`);
}
 export async function PostTarefa(tarefa){
    return await Api.post("/Tarefa/PostTarefa", tarefa);
 }

 export async function PutTarefa(tarefa){
    return await Api.put("/Tarefa/PutTarefa", tarefa);
 }

 export async function DeleteTarefa(id){
    return await Api.delete(`/Tarefa/DeleteTarefa/${id}`)
 }