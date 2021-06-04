// It can fetch data
// It returns a loading state
// It returns an error state

import React, { useState, useEffect } from "react";
import GetHeader from "./headers";


export type DocumentParam = {
    documentId: number;
    docTitle: string;
    docContent: string;
    dateCreated: any;
    dateModified: any;
    stateModelId: number;
    typeModelId: number;
    projectModelId: number;
    userModelId: number;
    docVersion: string;

};
const docParam: DocumentParam = {
    documentId: 2,
    docTitle: "Title#1",
    docContent: "Content#1",
    dateCreated: Date(),
    dateModified: Date(),
    stateModelId: 1,
    typeModelId: 1,
    projectModelId: 1,
    userModelId: 1,
    docVersion: "1.0.0"
}

const headers = GetHeader();


export async function createDocument(docParam: DocumentParam): Promise<Response> {
    const url = 'https://localhost:5001/api/Documents';
    const opts: RequestInit = {
        method: 'POST',
        headers,
        body: JSON.stringify(docParam),
    };
    return fetch(url, opts)
}


export async function GetDocuments(): Promise<Response> {
    const url = 'https://localhost:5001/api/Documents';
    const opts: RequestInit = {
        method: 'GET',
        headers,
    };
    return fetch(url, opts)
}

const useFetch = (url: RequestInfo, options: RequestInit) => {

    const [response, setResponse] = useState(null);
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);


    useEffect(() => {
        const abortController = new AbortController();
        const signal = abortController.signal;
        const doFetch = async () => {
            setLoading(true);

            try {
                const res = await fetch(url, options);
                const json = await res.json();
                if (!signal.aborted) {
                    setResponse(json);
                }
            } catch (e) {
                if (!signal.aborted) { setError(e); }
            } finally {
                if (!signal.aborted) { setLoading(false); }
            }
        };
        doFetch();
        return () => {
            abortController.abort();
        };
    }, [options, url]);
    return { response, error, loading };
};


export default useFetch;