function addImage()
{
    let divShowInput = document.getElementById("addImageId")
    if (divShowInput.style.display === "none") {
        divShowInput.style.display = "block"
    } else {
        divShowInput.style.display = "none"
    }
}