import React from "react";

const Table = ({dados = [], className = 'table table-stripped'}) => {
return(
    <>
       <table className={className} id="tabela">
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
                {dados && dados?.map(membros => {
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
    </>
)

}

export default Table;