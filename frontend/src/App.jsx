import Button from '@mui/material/Button';
import {useState} from 'react';
import {List, ListItem, ListItemButton, ListItemText} from '@mui/material';
import {useNavigate} from 'react-router-dom';

export default function App() {
    const [id, setId] = useState('');
    const [results, setResult] = useState([]);
    const navigate = useNavigate(); //Aufruf

    return (
        <>
            <Button   //Auslösebutton
                onClick={async () => {

                    navigate(`/Cashier`);
                }}
            >Kassierer</Button>
            <Button   //Auslösebutton
                onClick={async () => {

                    navigate(`/Stockman`);
                }}
            >Tierpfleger</Button>
            <Button   //Auslösebutton
                onClick={async () => {

                    navigate(`/Visitor`);
                }}
            >Zoobesucher</Button>
        </>
    );
}