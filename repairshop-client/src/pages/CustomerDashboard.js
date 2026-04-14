import { useState, useEffect } from 'react';
import api from '../services/api';
import { jwtDecode } from 'jwt-decode';



function CustomerDashboard() {
    const [requests, setRequests] = useState([]);
    const [email, setEmail] = useState('');

    useEffect(() => {
        const fetchRequests = async () => {
            const token = localStorage.getItem('token');
            const decoded = jwtDecode(token);
            setEmail(decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]);
            const userId = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
            const response = await api.get(`/RepairRequest/user/${userId}`);
            setRequests(response.data);
        };
        fetchRequests();  
    }, []);

    return (
        <div>
            <h1>Customer Dashboard</h1>
            <p>Hello {email}</p>
            {requests.map(r => (
                <div key={r.id}>
                    <p>{r.description} - {r.status}</p>
                </div>
            ))}
        </div>
    );
}

export default CustomerDashboard;