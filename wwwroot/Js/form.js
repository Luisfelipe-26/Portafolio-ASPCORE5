//Luis Felipe//Visor PDF
var btno = document.getElementById("openpdf");


function closepdf() {
	var cerrarb = document.getElementById("cerrarb");
	var framepdf = document.getElementById("framepdf");
	var containerpdf = document.getElementById("containerpdf");
	//delete element
	framepdf.parentElement.removeChild(framepdf);
	cerrarb.parentElement.removeChild(cerrarb);
	containerpdf.parentElement.removeChild(containerpdf);
	//disabled butom


}

function openpdf() {
	var containerpdf = document.getElementById("containerpdf");
	var container = document.createElement("div")
	var cerrarb = document.createElement("a");
	var framepdf = document.createElement("iframe");
	var cerrart = document.createTextNode("Cerrar PDF");

	if (containerpdf == null) {

		//BUTTOM CLOSE PDF
		cerrarb.appendChild(cerrart);
		cerrarb.setAttribute("href", "javascript:closepdf()");
		document.body.appendChild(cerrarb);
		cerrarb.setAttribute("id", "cerrarb");
		cerrarb.setAttribute("class", "btn btn-danger");
		//DOCUMENT PDF
		framepdf.setAttribute("id", "framepdf");
		framepdf.setAttribute("src", "http://docs.google.com/gview?url=https://drive.google.com/file/d/1F8dRYzOxyA6XBLXOIqiJJG48U0qub86i/view?usp=sharing&embedded=trued");
		document.body.appendChild(framepdf);


		framepdf.style.position = "float";
		//container pdf 
		container.appendChild(cerrarb);
		container.appendChild(framepdf);
		container.setAttribute("id", "containerpdf");
		document.body.appendChild(container);
	} else {
		alert("Ya esta abierto el pdf.");
	}

	

    
}


