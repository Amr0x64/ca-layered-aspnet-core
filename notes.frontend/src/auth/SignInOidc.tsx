import {useEffect, FC} from "react";
import { useNavigate } from "react-router-dom";
import { signinRedirectCallback } from "./user-service";

const SignInOidc: FC<{}> = () => {
    const navigate = useNavigate();
    useEffect(() => {
        async function signinAsync() {
            await signinRedirectCallback();
            navigate("/");
        }
        signinAsync();
    }, [navigate]);
    return <div>Redirecring...</div>;
};

export default SignInOidc;