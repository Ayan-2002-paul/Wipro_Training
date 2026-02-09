let message = "Hello, TypeScript!";
console.log(message);

let count: number = 10;
console.log("Count:", count);

function add(a: number, b: number): number {
  return a + b;
}

const sum = add(5, 10);
console.log("Sum:", sum);

interface User {
  name: string;
  age: number;
}

const user: User = {
  name: "Alice",
  age: 30
};

console.log("User:", user);

function printId(id: number | string): void {
  console.log("ID:", id);
}

printId(101);
printId("ABC123");

function processInput(input: string | string[]): void {
  if (typeof input === "string") {
    console.log("Single string:", input);
  } else {
    console.log("Array of strings:", input.join(", "));
  }
}

processInput("Hello");
processInput(["Hello", "World"]);

interface SuccessResponse {
  status: "success";
  data: any;
}

interface ErrorResponse {
  status: "error";
  message: string;
}

type ApiResponse = SuccessResponse | ErrorResponse;

function handleApiResponse(response: ApiResponse): void {
  if (response.status === "success") {
    console.log("API Data:", response.data);
  } else {
    console.error("API Error:", response.message);
  }
}

handleApiResponse({ status: "success", data: { id: 1, name: "Alice" } });
handleApiResponse({ status: "error", message: "Something went wrong" });

interface UserProfile {
  username: string;
  email: string;
  phoneNumber?: string;
}

const profile1: UserProfile = {
  username: "john_doe",
  email: "john@example.com"
};

const profile2: UserProfile = {
  username: "jane_doe",
  email: "jane@example.com",
  phoneNumber: "1234567890"
};

console.log("Profile 1:", profile1);
console.log("Profile 2:", profile2);

interface Item {
  name: string;
  price: number;
}

function calculateTotalPrice(items: Item[]): number {
  let total = 0;

  for (const item of items) {
    total += item.price;  
  }

  return total;
}

function checkout(items: Item[]): void {
  const total = calculateTotalPrice(items);
  console.log("Total Price:", total);
}

const cart: Item[] = [
  { name: "Laptop", price: 999.99 },
  { name: "Mouse", price: 49.99 }
];

checkout(cart);

type Person = {
  name: string;
  birthYear: number;
};

function calculateAge(person: Person): number {
  const currentYear = new Date().getFullYear();
  return currentYear - person.birthYear;
}

function printPersonDetails(person: Person): void {
  const age = calculateAge(person);
  console.log(`Person: ${person.name}, Age: ${age}`);
}

const person: Person = {
  name: "Rahul",
  birthYear: 2025   
};

printPersonDetails(person);