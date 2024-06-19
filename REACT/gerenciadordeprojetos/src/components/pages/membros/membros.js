import React, {useEffect, useState} from "react";
import { DeleteMembro, GetMembros, PostMembros, PutMembros } from "../../../services/serviceMembros";
import '../membros/membros.css';
import Table from "../../commons/table/table";

const Membros = () => {
    const [alterar, setAlterar] = useState(false);
    const [textoBotao, setTextoBotao] = useState("Salvar");
    const [listaMembros, setListaMembros] = useState([]);
    const [membros, setMembros] = useState({});
    const [salvou, setSalvou] =useState(false);
    const [habilitar, setHabilitar] = useState(true);

    const columns = [
        {name: 'Nome', columnType: 'texto'},
        {name: 'CPF', columnType: 'texto'},
        {name: 'Sexo', columnType: 'texto'},
        {name: 'Email', columnType: 'texto'},
        {name: 'Telefone', columnType: 'texto'},
        {name: 'Data de Nascimento', columnType: 'texto'},
        {name: 'Ação', columnType: 'botao'}
    ]

    const dataSource = listaMembros && listaMembros?.map(item => [
        {name: item.memNome},
        {name: item.memCPF},
        {name: item.memSexo},
        {name: item.memEmail},
        {name: item.memTelefone},
        {name: item.memDataNascimento},
        {
            botoes:[{
                botao: <button onClick={() => CarregarMembros(item)} style={{marginLeft:"5px"}} className="btn btn-sm btn-primary" type="button">Editar</button>
            },
            {
                botao: <button onClick={() => ExcluirMembro(item.memCodigo)} className="btn btn-sm btn-danger" type="button">Excluir</button>
            }
        
        
        ]
        }
    ])

    const handleChange = (event,value) => {
        membros[event.target.id] = value;
        setMembros({...membros});
    }

    const handleSalvar = () =>{
        if (alterar){
            PutMembros(membros).then(res => setSalvou(true));
            
        }
        else{
            PostMembros(membros).then(res => setSalvou(true));
            setMembros({});
        }
        
    }

    const NovoMembro = () =>{
        setMembros({});
        setHabilitar(false);
    }
    const CarregarMembros = (membros) =>{
        setMembros(membros);
        setAlterar(true);
    }

    const ExcluirMembro = (id) => {
        DeleteMembro(id).then(res => {console.log(res.data)});
        setSalvou(true);
    }

    useEffect(() => {
        // GetMembros().then(res => {console.log('res',res.data)})
        GetMembros().then(res => setListaMembros(res.data));
    },[salvou])

    useEffect(() => {
        setTextoBotao(alterar ? "Alterar" : "Salvar")
    },[alterar])

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
                            <input readOnly={habilitar} type="text" id="memNome" value={membros.memNome || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>   
                    <div style={{padding: "10px"}}  className="col-md-2">
                        <div>
                            <label>CPF</label>
                            <input readOnly={habilitar} type="text" id="memCPF" value={membros.memCPF || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{padding: "10px"}}  className="col-md-1">
                        <div>
                            <label>Sexo</label>
                            <input readOnly={habilitar} type="text" id="memSexo" value={membros.memSexo || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <div style={{display: "flex"}}>
                    <div style={{padding: "10px"}}  className="col-md-3">
                        <div>
                            <label>Email</label>
                            <input readOnly={habilitar} type="text" id="memEmail" value={membros.memEmail || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>   
                    <div style={{padding: "10px"}}  className="col-md-3">
                        <div>
                            <label>Telefone</label>
                            <input readOnly={habilitar} type="text" id="memTelefone" value={membros.memTelefone || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{padding: "10px"}}  className="col-md-2">
                        <div>
                            <label>Data de Nascimento</label>
                            <input readOnly={habilitar} type="date" id="memDataNascimento" value={membros.memDataNascimento || ""} onChange={(e) => handleChange(e, e.target.value)} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <button onClick={handleSalvar} type="button" className="btn btn-success">{textoBotao}</button>
                <button onClick={NovoMembro} type="button" className="btn btn-primary">Novo Membro</button>
            </div>

                <div>
                    <Table dados={dataSource} columns={columns}></Table>
                </div>
        </div>
    );
}
export default Membros;