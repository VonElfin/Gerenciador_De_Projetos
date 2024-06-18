import React, {useEffect, useState} from "react";
import { GetMembros, PostMembros } from "../../../services/serviceMembros";
import '../membros/membros.css';

const Membros = () => {

    const [listaMembros, setListaMembros] = useState([]);
    const [membros, setMembros] = useState({});

    const handleChange = (event,value) => {
        membros[event.target.id] = value;
        setMembros({...membros});
    }

    const handleSalvar = () =>{
        console.log("membro", membros);
        PostMembros(membros).then(res => {console.log(res.data)});
    }

    useEffect(() => {
        // GetMembros().then(res => {console.log('res',res.data)})
        GetMembros().then(res => setListaMembros(res.data));
    },[])
    return (
        <div style={{marginLeft: "10px"}}>
            <div>
                <h2>Cadastro de Membros</h2>
            </div>
            <div>
                <div style={{display: "flex"}}>
                    <div style={{padding: "10px"}}  className="col-md-3">
                        <div>
                            <label>Nome</label>
                            <input type="text" id="memNome" value={membros.memNome || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>   
                    <div style={{padding: "10px"}}  className="col-md-2">
                        <div>
                            <label>CPF</label>
                            <input type="text" id="memCPF" value={membros.memCPF || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{padding: "10px"}}  className="col-md-1">
                        <div>
                            <label>Sexo</label>
                            <input type="text" id="memSexo" value={membros.memSexo || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <div style={{display: "flex"}}>
                    <div style={{padding: "10px"}}  className="col-md-3">
                        <div>
                            <label>Email</label>
                            <input type="text" id="memEmail" value={membros.memEmail || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>   
                    <div style={{padding: "10px"}}  className="col-md-3">
                        <div>
                            <label>Telefone</label>
                            <input type="text" id="memTelefone" value={membros.memTelefone || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{padding: "10px"}}  className="col-md-2">
                        <div>
                            <label>Data de Nascimento</label>
                            <input type="date" id="memDataNascimento" value={membros.memDataNascimento || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <button onClick={handleSalvar} type="button" className="btn btn-success">Salvar</button>
            </div>

                <div>
                    <table className="table table-stripped">
                        <thead>
                            <tr>
                                <th>
                                    Nome
                                </th>
                                <th>
                                    CPF
                                </th>
                            </tr>
                        </thead>
                    
                        <tbody>
                            {listaMembros && listaMembros?.map(membros => {
                                // console.log('item',membros);
                                return(
                                    <tr key={membros.memNome}>
                                        <td key={"col_"+membros.memNome}>
                                            {membros.memNome}
                                        </td>
                                        <td key={"col_"+membros.memCPF}>
                                            {membros.memCPF}
                                        </td>
                                    </tr>
                                )
                            })}
                        </tbody>
                    </table>
                </div>
        </div>
    );
}
export default Membros;