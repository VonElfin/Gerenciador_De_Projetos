import axios from 'axios';

var urlBase = "http://localhost:5062/api"
    const Api = axios.create({
        baseUrl: urlBase
    })

export default Api;