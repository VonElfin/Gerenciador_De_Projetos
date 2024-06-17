import React,{useState, useEffect} from "react";
import { GetMembros } from "./services/serviceMembros";

const App = () =>{
  useEffect(() => {
GetMembros().then(res => {console.log(res.data)})
  },[])
  
  return (
    <>
    <h2>Olá Mundo!</h2>
    </>
  )
}
export default App;
