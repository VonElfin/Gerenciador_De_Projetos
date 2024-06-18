import axios from 'axios';

// var urlBase = "http://localhost:5062/api"
//     const Api = axios.create({
//         baseUrl: urlBase
//     })

// export default Api;

const Api = axios.create({
    baseURL: "http://localhost:5062/api"
})

// Api.interceptors.response.use(
//     (res) => {
//         console.log('Ok')

//         return res;
//     },
//     (err) => err
// )

export default Api;