import { useEffect, useState } from "react"
import { useAuth0 } from "@auth0/auth0-react";
import WorkItemType from "./WorkItemType";

const WorkItemTypeList = () => {
    const { getAccessTokenSilently } = useAuth0();
    const [workItemTypes, setWorkItemTypes] = useState([]);

    useEffect(() => {


        const fetchWorkItemTypes = async () => {
            const token = await getAccessTokenSilently({
                audience: "https://amillner-ado-clone/",
            });

            const res = await fetch(`${process.env.REACT_APP_API_URL}/workItemType`,
                {
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                }
            );

            var body = await res.json();
            setWorkItemTypes(body);
        }

        fetchWorkItemTypes();
    }, [getAccessTokenSilently])

    return (
        <>
            <h1>WorkItemTypes</h1>
            {workItemTypes.map((workItemType) => (
                <WorkItemType key={workItemType.id} workItemType={workItemType} />
            ))}
        </>
    )
}


export default WorkItemTypeList