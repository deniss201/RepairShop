import { BrowserRouter, Routes, Route } from 'react-router-dom';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage'
import Admin from './pages/AdminDashboard'
import Customer from './pages/CustomerDashboard'

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/login" element={<LoginPage />} />
                <Route path="/register" element={<RegisterPage />} />
                <Route path="/admin" element={<Admin />} />
                <Route path="/dashboard" element={<Customer />} />
            </Routes>

        </BrowserRouter>
    );
}

export default App;