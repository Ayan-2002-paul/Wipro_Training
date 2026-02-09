// Creating a Hello World program in TypeScript

console.log("Hello, World!");

let message: string = "Hello, TypeScript!";
console.log(message);

function greet(name: string): string {
    return `Hello, ${name}!`;
}

console.log(greet("Ayan"));

// Explicit typing
let message1: string = "Hello, TypeScript!";
console.log(message1);

// Type inference
let age = 30; // inferred as number
console.log(`I am ${age} years old.`);

// Boolean type
let isActive: boolean = true;

if (isActive) {
    console.log("The user is active.");
} else {
    console.log("The user is not active.");
}

// Optional parameter
function introduce(name: string, age?: number): string {
    if (age !== undefined) {
        return `Hello, ${name}! You are ${age} years old.`;
    } else {
        return `Hello, ${name}!`;
    }
}

console.log(introduce("Alice", 25));
console.log(introduce("Bob"));

// Default parameter
function multiply(a: number, b: number = 2): number {
    return a * b;
}

console.log(multiply(5));
console.log(multiply(5, 3));
