import React, {useEffect, useState} from "react";
import { GetMembros } from "../../../services/serviceMembros";

const Membros = () => {

const [listaMembros, setListaMembros] = useState([]);

useEffect(() => {
    GetMembros().then(res => {console.log('res',res.data)})
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
            </div>
        </>
    );
}
export default Membros;