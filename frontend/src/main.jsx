import React from 'react'
import ReactDOM from 'react-dom/client'
import Cashier from './Cashier.jsx'
import Stockman from './Stockman.jsx'
import Visitor from './Visitor.jsx'
import App from './App.jsx'
import './index.css'
import {
    createBrowserRouter,
    RouterProvider,
} from 'react-router-dom';

const router = createBrowserRouter([
    {
        path: "/", //Hauptansicht reicht /
        element: <App/>,
    },
    {
        path: "/Cashier",
        element: <Cashier/>,
    },
    {
        path: "/Stockman",
        element: <Stockman/>,
    },

    {
        path: "/Visitor",
        element: <Visitor/>
    }
])

ReactDOM.createRoot(document.getElementById('root')).render(
    <React.StrictMode>
        <RouterProvider router={router}/>
    </React.StrictMode>,
);
