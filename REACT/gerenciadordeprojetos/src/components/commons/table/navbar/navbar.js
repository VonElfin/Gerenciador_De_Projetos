// import React from "react";
// import { Container, Nav, Navbar, useNavigate } from "react-bootstrap";
// import { Link, Route, Routes} from "react-router-dom";
// import Membros from "../../../pages/membros/membros";

// const NavBarMain = () =>{
//     return(
//         <nav>
//             <Navbar style={{backgroundColor: "#5F9EA0"}}>
//                 <Container>
//                     <Nav>
//                         <Link to="/membros">Membros</Link>
//                     </Nav>
//                 </Container>
//             </Navbar>
//             <Routes>
//                 <Route index path="/membros" element = {Membros}></Route>
//             </Routes>
//         </nav>
//     )
// }

// export default NavBarMain;

import React from "react";
import './navbar.css';
import Membros from "../../../pages/membros/membros";

const NavBarMain = () => {
    return(
        <header className="header">
            <a href="/" className="logo">Logo</a>

            <nav className="navbar">
                <a href="/">Membros</a>
                <a href="/">Projeto</a>
                <a href="/">Tarefa</a>
            </nav>
        </header>
    )
}
export default NavBarMain;