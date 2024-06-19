import React, { useEffect, useState } from "react";
import { DeleteTarefa, GetTarefa, PostTarefa, PutTarefa } from "../../../services/serviceTarefa";
import "../tarefa/tarefa.css";
import Table from "../../commons/table/table";

const Tarefa = () => {
    const [alterar, setAlterar] = useState(false);
    const [textoBotao, setTextoBotao] = useState("Salvar");
    const [listaTarefa, setListaTarefa] = useState([]);
    const [tarefa, setTarefa] = useState({});
    const [salvou, setSalvou] = useState(false);
    const [habilitar, setHabilitar] = useState(true);

    const columns = [
        { name: 'Codigo Projeto', columnType: 'texto' },
        { name: 'Nome', columnType: 'texto' },
        { name: 'Descricao', columnType: 'texto' },
        { name: 'Status', columnType: 'texto' },
        { name: 'Data de Incio', columnType: 'texto' },
        { name: 'Data Final', columnType: 'texto' },
        {name: 'Ação', columnType: 'botao'}
    ];

    const dataSource = listaTarefa && listaTarefa.map(item => [
        { name: item.tarCodigoProjeto },
        { name: item.tarNome },
        { name: item.tarDescricao },
        { name: item.tarStatus ? "Ativo" : "Inativo" },
        { name: item.tarDataInicio },
        { name: item.tarDataFinal },
        {
            botoes: [
                {
                    botao: <button onClick={() => CarregarTarefa(item)} style={{ marginLeft: "5px" }} className="btn btn-sm btn-primary" type="button">Editar</button>
                },
                {
                    botao: <button onClick={() => ExcluirTarefa(item.tarCodigo)} className="btn btn-sm btn-danger" type="button">Excluir</button>
                }
            ]
        }
    ]);

    const handleChange = (event) => {
        const { id, value } = event.target;
        const newValue = id === "tarStatus" ? (value === "Ativo") : value;
        setTarefa(prevState => ({
            ...prevState,
            [id]: newValue
        }));
    };

    const handleSalvar = () => {
        if (alterar){
            PutTarefa(tarefa).then(res => setSalvou(true));
        }
        else{
            PostTarefa(tarefa).then(res => setSalvou(true));
            setTarefa({});
        };
    };

    const NovaTarefa = () =>{
        setTarefa({});
        setHabilitar(false);
    };

    const CarregarTarefa = (tarefa) => {
        setTarefa(tarefa);
        setAlterar(true);
    };

    const ExcluirTarefa = (id) => {
        DeleteTarefa(id).then(res => { console.log(res.data) });
        setSalvou(true);
    };

    useEffect(() => {
        GetTarefa().then(res => setListaTarefa(res.data));
    }, [salvou])

    useEffect(() => {
        setTextoBotao(alterar ? "Alterar" : "Salvar");
    }, [alterar]);

    return(
        <div style={{ marginLeft: "10px" }}>
            <div>
                <h2>Cadastro de Tarefa</h2>
            </div>
            <div>
                <div style={{ display: "flex" }}>
                    <div style={{ padding: "10px" }} className="col-md-3">
                        <div>
                            <label>Codigo do Projeto</label>
                            <input readOnly={habilitar} type="text" id="tarCodigoProjeto" value={tarefa.tarCodigoProjeto || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-3">
                        <div>
                            <label>Nome</label>
                            <input readOnly={habilitar} type="text" id="tarNome" value={tarefa.tarNome || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-3">
                        <div>
                            <label>Descricao</label>
                            <input readOnly={habilitar} type="text" id="tarDescricao" value={tarefa.tarDescricao || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-1">
                        <div>
                            <label>Status</label>
                            <select readOnly={habilitar} id="tarStatus" value={tarefa.tarStatus ? "Ativo" : "Inativo"} onChange={handleChange} className="form-control">
                                <option value="Ativo">Ativo</option>
                                <option value="Inativo">Inativo</option>
                            </select>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-2">
                        <div>
                            <label>Data de Inicio</label>
                            <input readOnly={habilitar} type="date" id="tarDataInicio" value={tarefa.tarDataInicio || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-2">
                        <div>
                            <label>Data de Final</label>
                            <input readOnly={habilitar} type="date" id="tarDataFinal" value={tarefa.tarDataFinal || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <button onClick={handleSalvar} type="button" className="btn btn-success">{textoBotao}</button>
                <button onClick={NovaTarefa} type="button" className="btn btn-primary">Nova Tarefa</button>
            </div>

            <div>
                <Table dados={dataSource} columns={columns}></Table>
            </div>

        </div>
    )

}

export default Tarefa;