import React,{useState, useEffect} from "react";
import { GetMembros } from "./services/serviceMembros";
import Membros from "./components/pages/membros/membros";

const App = () =>{
  useEffect(() => {
    GetMembros().then(res => {console.log(res.data)})
  },[])
  
  return (
    <>
      <Membros></Membros>
    </>
  )
}
export default App;
