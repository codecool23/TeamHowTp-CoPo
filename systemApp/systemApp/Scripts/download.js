function download() {
    var a = document.body.appendChild(
        document.createElement("a")
    );
    a.download = "export.html";
    a.href = "data:text/html," + document.getElementById("content").innerHTML; // Grab the HTML
    a.click(); // Trigger a click on the element
}