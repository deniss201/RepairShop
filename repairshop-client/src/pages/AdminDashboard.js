import { useState, useEffect } from 'react';
import api from '../services/api';
import { jwtDecode } from 'jwt-decode';




function AdminDashboard() {
    const [email, setEmail] = useState('');


     useEffect(() => {
            const token = localStorage.getItem('token');
            const decoded = jwtDecode(token);
            setEmail(decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"]);
    }, []);

    return (
        <div>
            <h1>Admin Dashboard</h1>
            <p>Welcome {email}</p>
        </div>
    );
}

export default AdminDashboard;