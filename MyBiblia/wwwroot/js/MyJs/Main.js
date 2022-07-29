//$(document).ready(() => {
//    Libros();
//})

const Libros = async () => {
    let url = "https://localhost:7205/Home/Lista_De_Libros";

    let res = await axios.get(url)

    if (res.data.result) {

       let mydata = JSON.parse(res.data.result)

        mydata.map(e => {
            let html = `
           <tr>
              <td>${e.nombre}</td>
              <td>${e.descripcion}</td>
               <td>
                  <button onclick="modalReutilizable()" class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#exampleModal">Editar</button>
                  <button onclick="EliminarTarea(${e.id})" class="btn btn-danger">Eliminar</button>
              </td>
           </tr>`

            console.log(e.Id);
            document.getElementById("tbody").innerHTML += html;
        })
        console.log(res.data.result)
    }
}

const EliminarTarea = (id) => {

    let url = `https://localhost:7205/Home/Eliminar/${id}`;

    let respuesta = await axios.delete(url);

    console.log(respuesta.result);
}