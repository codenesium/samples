import React, { Component } from 'react';
import axios from 'axios';
import * as Api from '../../api/models';
import { UpdateResponse } from '../../api/ApiObjects'
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import { FormikProps,FormikErrors, Field, withFormik } from 'formik';
import { LoadingForm } from '../../lib/components/loadingForm'
import { ErrorForm } from '../../lib/components/errorForm'
import FollowingMapper from './followingMapper';
import FollowingViewModel from './followingViewModel';

interface Props {
	history:any;
    model?:FollowingViewModel
}

const FollowingDetailDisplay = (model:Props) => {

   return (
          <form  role="form">
				<button
                  className="btn btn-primary btn-sm align-middle float-right vertically-center"
                  onClick={(e) => { model.history.push(ClientRoutes.Followings + '/edit/' + model.model!.userId)}}
                >
                  <i className="fas fa-edit" />
                </button>
			 						 <div className="form-group row">
							<label htmlFor="dateFollowed" className={"col-sm-2 col-form-label"}>Date_followed</label>
							<div className="col-sm-12">
								{String(model.model!.dateFollowed)}
							</div>
						</div>
					   						 <div className="form-group row">
							<label htmlFor="muted" className={"col-sm-2 col-form-label"}>Muted</label>
							<div className="col-sm-12">
								{String(model.model!.muted)}
							</div>
						</div>
					             </form>
  );
}

  interface IParams 
  {
     userId:number;
  }
  
  interface IMatch
  {
     params: IParams;
  }

  interface FollowingDetailComponentProps
  {
     match:IMatch;
	 history:any;
  }

  interface FollowingDetailComponentState
  {
      model?:FollowingViewModel;
      loading:boolean;
      loaded:boolean;
      errorOccurred:boolean;
      errorMessage:string;
  }


  export default class FollowingDetailComponent extends React.Component<FollowingDetailComponentProps, FollowingDetailComponentState> {

    state = ({model:undefined, loading:false, loaded:false, errorOccurred:false, errorMessage:''});

    componentDidMount () {
        this.setState({...this.state,loading:true});

        axios.get(Constants.ApiEndpoint + ApiRoutes.Followings + '/' + this.props.match.params.userId,
        {
            headers: {
                'Content-Type': 'application/json',
            }
        })
        .then(resp => {
            let response = resp.data as Api.FollowingClientResponseModel;
            
			let mapper = new FollowingMapper();

            console.log(response);

            this.setState({model:mapper.mapApiResponseToViewModel(response), loading:false, loaded:true, errorOccurred:false, errorMessage:''});

        }, error => {
            console.log(error);
            this.setState({model:undefined, loading:false, loaded:false, errorOccurred:true, errorMessage:'Error from API'});
        })
    }
    render () {

        if (this.state.loading) {
            return <LoadingForm />;
        } 
		else if (this.state.errorOccurred) {
            return <ErrorForm message={this.state.errorMessage} />;
        }
        else if (this.state.loaded) {
            return (<FollowingDetailDisplay history={this.props.history} model={this.state.model} />);
        } 
		else {
		  return null;
		}
    }
}

/*<Codenesium>
    <Hash>43eeec99169ac5a3851fb4e6b9a9794a</Hash>
</Codenesium>*/