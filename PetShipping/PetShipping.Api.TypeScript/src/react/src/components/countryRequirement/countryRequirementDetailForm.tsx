import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CountryRequirementMapper from './countryRequirementMapper';
import CountryRequirementViewModel from './countryRequirementViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface CountryRequirementDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CountryRequirementDetailComponentState {
  model?: CountryRequirementViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CountryRequirementDetailComponent extends React.Component<
CountryRequirementDetailComponentProps,
CountryRequirementDetailComponentState
> {
  state = {
    model: new CountryRequirementViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.CountryRequirements + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CountryRequirements +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.CountryRequirementClientResponseModel;

          console.log(response);

          let mapper = new CountryRequirementMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div style={{"marginBottom":"10px"}}>
							<h3>countryId</h3>
							<p>{String(this.state.model!.countryIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>details</h3>
							<p>{String(this.state.model!.detail)}</p>
						 </div>
					   						 <div>
							<h3>id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCountryRequirementDetailComponent = Form.create({ name: 'CountryRequirement Detail' })(
  CountryRequirementDetailComponent
);

/*<Codenesium>
    <Hash>483ae773c52857df47e85359151df494</Hash>
</Codenesium>*/