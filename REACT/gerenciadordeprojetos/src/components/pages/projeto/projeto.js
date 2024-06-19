import React, { useEffect, useState } from "react";
import { DeleteProjeto, GetProjeto, PostProjeto, PutProjeto } from "../../../services/serviceProjeto";
import "../projeto/projeto.css";
import Table from "../../commons/table/table";

const Projeto = () => {
    const [alterar, setAlterar] = useState(false);
    const [textoBotao, setTextoBotao] = useState("Salvar");
    const [listaProjeto, setListaProjeto] = useState([]);
    const [projeto, setProjeto] = useState({});
    const [salvou, setSalvou] = useState(false);
    const [habilitar, setHabilitar] = useState(true);

    const columns = [
        { name: 'Nome', columnType: 'texto' },
        { name: 'Status', columnType: 'texto' },
        { name: 'Data de Inicio', columnType: 'texto' },
        { name: 'Data Final', columnType: 'texto' },
        {name: 'Ação', columnType: 'botao'}
    ];

    const dataSource = listaProjeto && listaProjeto.map(item => [
        { name: item.proNome },
        { name: item.proStatus ? "Ativo" : "Inativo" },
        { name: item.proDataInicio },
        { name: item.proDataFinal },
        {
            botoes: [
                {
                    botao: <button onClick={() => CarregarProjeto(item)} style={{ marginLeft: "5px" }} className="btn btn-sm btn-primary" type="button">Editar</button>
                },
                {
                    botao: <button onClick={() => ExcluirProjeto(item.proCodigo)} className="btn btn-sm btn-danger" type="button">Excluir</button>
                }
            ]
        }
    ]);

    const handleChange = (event) => {
        const { id, value } = event.target;
        const newValue = id === "proStatus" ? (value === "Ativo") : value;
        setProjeto(prevState => ({
            ...prevState,
            [id]: newValue
        }));
    };

    const handleSalvar = () => {
        if (alterar) {
            PutProjeto(projeto).then(res => setSalvou(true));
        } else {
            PostProjeto(projeto).then(res => setSalvou(true));
            setProjeto({});
        }
    };

    const NovoProjeto = () => {
        setProjeto({});
        setHabilitar(false);
    };

    const CarregarProjeto = (projeto) => {
        setProjeto(projeto);
        setAlterar(true);
    };

    const ExcluirProjeto = (id) => {
        DeleteProjeto(id).then(res => { console.log(res.data) });
        setSalvou(true);
    };

    useEffect(() => {
        GetProjeto().then(res => setListaProjeto(res.data));
    }, [salvou]);

    useEffect(() => {
        setTextoBotao(alterar ? "Alterar" : "Salvar");
    }, [alterar]);

    return (
        <div style={{ marginLeft: "10px" }}>
            <div>
                <h2>Cadastro de Projeto</h2>
            </div>
            <div>
                <div style={{ display: "flex" }}>
                    <div style={{ padding: "10px" }} className="col-md-3">
                        <div>
                            <label>Nome</label>
                            <input readOnly={habilitar} type="text" id="proNome" value={projeto.proNome || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-1">
                        <div>
                            <label>Status</label>
                            <select readOnly={habilitar} id="proStatus" value={projeto.proStatus ? "Ativo" : "Inativo"} onChange={handleChange} className="form-control">
                                <option value="Ativo">Ativo</option>
                                <option value="Inativo">Inativo</option>
                            </select>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-2">
                        <div>
                            <label>Data de Inicio</label>
                            <input readOnly={habilitar} type="date" id="proDataInicio" value={projeto.proDataInicio || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                    <div style={{ padding: "10px" }} className="col-md-2">
                        <div>
                            <label>Data de Final</label>
                            <input readOnly={habilitar} type="date" id="proDataFinal" value={projeto.proDataFinal || ""} onChange={handleChange} className="form-control"></input>
                        </div>
                    </div>
                </div>
                <button onClick={handleSalvar} type="button" className="btn btn-success">{textoBotao}</button>
                <button onClick={NovoProjeto} type="button" className="btn btn-primary">Novo Projeto</button>
            </div>

            <div>
                <Table dados={dataSource} columns={columns}></Table>
            </div>

        </div>
    )
}

export default Projeto;
