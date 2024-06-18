import React, {useEffect, useState} from "react";
import { GetMembros } from "../../../services/serviceMembros";

const Membros = () => {

const [listaMembros, setListaMembros] = useState([]);

    useEffect(() => {
        // GetMembros().then(res => {console.log('res',res.data)})
        GetMembros().then(res => setListaMembros(res.data));
    },[])
    return (
        <>
        <div>
            <h2>Cadastro de Membros</h2>
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
                </table>
                <tbody>
                    {listaMembros && listaMembros?.map(membros => {
                        console.log('item',membros);
                        return(
                            <tr>
                                <td>
                                    {membros.memNome}
                                </td>
                                <td>
                                    {membros.memCPF}
                                </td>
                            </tr>
                        )
                    })}
                </tbody>
            </div>
        </>
    );
}
export default Membros;