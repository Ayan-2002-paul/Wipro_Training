const cart = document.getElementById("cart");// Access the cart ul element
const addItemBtn = document.getElementById("addItem");// Access the Add Item button

let productCount = 1;// To keep track of product numbers

addItemBtn.addEventListener("click", function () {

    const li = document.createElement("li");
    li.innerHTML = `Product ${productCount}
        <button class="remove">Remove</button>`;

    cart.appendChild(li);// Append the new item to the cart
    productCount++;// Increment product count
});

cart.addEventListener("click", function (event) {// Listen for clicks on the cart

    // Check if Remove button was clicked
    if (event.target.classList.contains("remove")) {// If the clicked element has the class "remove"
        event.target.parentElement.remove();// Remove the corresponding product item
    }
});
document.body.addEventListener("click", function () {// Listen for clicks on the body (Capturing phase)
    console.log("Body clicked (Capturing phase)");// Log when the body is clicked
}, true); // true = capturing // false = bubbling

cart.addEventListener("click", function () {// Listen for clicks on the cart (Bubbling phase)
    console.log("Cart clicked (Bubbling phase)");// Log when the cart is clicked

});