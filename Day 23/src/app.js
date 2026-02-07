const app = document.getElementById("app");

// Cart
let cart = [];

// Data
const products = [
  { id: 1, name: "Laptop", price: "₹60,000" },
  { id: 2, name: "Headphones", price: "₹2,000" },
  { id: 3, name: "Smartphone", price: "₹25,000" },
  { id: 4, name: "Smartwatch", price: "₹5,000" },
  { id: 5, name: "Camera", price: "₹15,000" },
  { id: 6, name: "Tablet", price: "₹20,000" }
];

// Views
function loadHome() {
    app.innerHTML = `
    <h2>Welcome to QuickKart</h2>
    <p>Your one-stop product showcase.</p>
  `;
}

function addToCart(productId) {
  const product = products.find(p => p.id === productId);
  cart.push(product);
  alert(`${product.name} added to cart!`);
}

function loadProducts() {
  app.innerHTML = `
    <h2>Products</h2>
    <ol>
      ${products.map(p => `<li>${p.name} - ${p.price} <button onclick="addToCart(${p.id})">Add to Cart</button></li>`).join("")}
    </ol>
  `;
}

function loadCart() {
  if (cart.length === 0) {
    app.innerHTML = `<h2>Your Cart is Empty</h2>`;
    return;
  }
  const totalPrice = cart.reduce((sum, item) => sum + parseInt(item.price.replace(/[^0-9]/g, "")), 0);
  app.innerHTML = `
    <h2>Shopping Cart</h2>
    <ol>
      ${cart.map((p, i) => `<li>${p.name} - ${p.price} <button onclick="removeFromCart(${i})">Remove</button></li>`).join("")}
    </ol>
    <h3> Your Total: ₹${totalPrice.toLocaleString('en-IN')}</h3>
  `;
}

function removeFromCart(index) {
  cart.splice(index, 1);
  loadCart();
}

// Events
document.getElementById("homeBtn").addEventListener("click", loadHome);
document.getElementById("productsBtn").addEventListener("click", loadProducts);
document.getElementById("cartBtn").addEventListener("click", loadCart);