export const toLowerCaseFirstLetter = (obj:string) => {
  return obj.charAt(0).toLowerCase() + obj.slice(1);
}

export const defaultHeaders = () =>
{
   return  {
    'Content-Type': 'application/json',
    'Authorization': 'Bearer ' + window.localStorage.getItem('authToken')
  }
}

export const parseJWT = (token:string) => {
  try
  {
    let base64Url = token.split('.');
    if (base64Url.length > 1) {
      let base64 = base64Url[1].replace(/-/g, '+').replace(/_/g, '/');
      return JSON.parse(window.atob(base64));
    }
    else{
        return ''
    }
  }
  catch(e)
  {
    return '';
  }
};

export const logInfo = (message:any) => {
  console.log(message);
};

export const logError = (error:any) => {
  console.log(error);
};