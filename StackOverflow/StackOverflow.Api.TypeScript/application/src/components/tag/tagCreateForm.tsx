import React, { Component } from 'react';
import axios from 'axios';
import { CreateResponse } from '../../api/ApiObjects'
import { FormikProps, FormikErrors, Field, withFormik } from 'formik';
import * as Yup from 'yup'
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import * as Api from '../../api/models';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import TagMapper from './tagMapper';
import TagViewModel from './tagViewModel';

interface Props {
    model?:TagViewModel
}

   const TagCreateDisplay: React.SFC<FormikProps<TagViewModel>> = (props: FormikProps<TagViewModel>) => {

   let status = props.status as CreateResponse<Api.TagClientRequestModel>;
   
   let errorsForField = (name:string) : string =>
   {
        let response = '';
        if(props.touched[name as keyof TagViewModel]  && props.errors[name as keyof TagViewModel]) {
            response += props.errors[name as keyof TagViewModel];
        }

        if(status && status.validationErrors && status.validationErrors.find(f => f.propertyName.toLowerCase() == name.toLowerCase())) {
            response += status.validationErrors.filter(f => f.propertyName.toLowerCase() == name.toLowerCase())[0].errorMessage;
        }

        return response;
   }

   let errorExistForField = (name:string) : boolean =>
   {
        return errorsForField(name) != '';
   }

   return (<form onSubmit={props.handleSubmit} role="form">            
            			<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("count") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>Count</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="count" className={errorExistForField("count") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("count") && <small className="text-danger">{errorsForField("count")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("excerptPostId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>ExcerptPostId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="excerptPostId" className={errorExistForField("excerptPostId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("excerptPostId") && <small className="text-danger">{errorsForField("excerptPostId")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("tagName") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>TagName</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="tagName" className={errorExistForField("tagName") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("tagName") && <small className="text-danger">{errorsForField("tagName")}</small>}
                        </div>
                    </div>

						<div className="form-group row">
                        <label htmlFor="name" className={errorExistForField("wikiPostId") ? ("col-sm-2 col-form-label is-invalid") : "col-sm-2 col-form-label"}>WikiPostId</label>
					    <div className="col-sm-12">
                             <Field type="textbox" name="wikiPostId" className={errorExistForField("wikiPostId") ? "form-control is-invalid" : "form-control"} />
                            {errorExistForField("wikiPostId") && <small className="text-danger">{errorsForField("wikiPostId")}</small>}
                        </div>
                    </div>

			
            <button type="submit" className="btn btn-primary" disabled={false}>
                Submit
            </button>
            <br />
            <br />
            { 
                status && status.success ? (<div className="alert alert-success">Success</div>): (null)
            }
                        
            { 
                status && !status.success ? (<div className="alert alert-danger">Error occurred</div>): (null)
            }
          </form>);
}


const TagCreate = withFormik<Props, TagViewModel>({
    mapPropsToValues: props => {
                
		let response = new TagViewModel();
		if (props.model != undefined)
		{
			response.setProperties(props.model!.count,props.model!.excerptPostId,props.model!.id,props.model!.tagName,props.model!.wikiPostId);	
		}
		return response;
      },
  
    validate: values => {
      let errors:FormikErrors<TagViewModel> = { };

	  if(values.count == 0) {
                errors.count = "Required"
                    }if(values.excerptPostId == 0) {
                errors.excerptPostId = "Required"
                    }if(values.tagName == '') {
                errors.tagName = "Required"
                    }if(values.wikiPostId == 0) {
                errors.wikiPostId = "Required"
                    }

      return errors;
    },
  
    handleSubmit: (values, actions) => {
        actions.setStatus(undefined);
        let mapper = new TagMapper();

        axios.post(Constants.ApiEndpoint + ApiRoutes.Tags,
        mapper.mapViewModelToApiRequest(values),
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as CreateResponse<Api.TagClientRequestModel>;
            actions.setStatus(response);
            console.log(response);
    
        }, error => {
		    console.log(error);
            actions.setStatus('Error from API');
        })
    },
    displayName: 'TagCreate', 
  })(TagCreateDisplay);

  interface TagCreateComponentProps
  {
  }

  interface TagCreateComponentState
  {
      model?:TagViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }

  export default class TagCreateComponent extends React.Component<TagCreateComponentProps, TagCreateComponentState> {

    state = ({model:undefined, loading:false, loaded:true, errorOccurred:false, errorMessage:''});

    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
	    else if (this.state.errorOccurred) {
             return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<TagCreate model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>027cb74d1f803e8862c8863dcdaeba12</Hash>
</Codenesium>*/