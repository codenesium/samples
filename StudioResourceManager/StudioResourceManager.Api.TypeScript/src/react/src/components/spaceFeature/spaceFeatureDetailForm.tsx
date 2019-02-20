import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { LoadingForm } from '../../lib/components/loadingForm';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import SpaceFeatureMapper from './spaceFeatureMapper';
import SpaceFeatureViewModel from './spaceFeatureViewModel';
import { Form, Input, Button } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { Alert } from 'antd';

interface SpaceFeatureDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface SpaceFeatureDetailComponentState {
  model?: SpaceFeatureViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class SpaceFeatureDetailComponent extends React.Component<
SpaceFeatureDetailComponentProps,
SpaceFeatureDetailComponentState
> {
  state = {
    model: new SpaceFeatureViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.SpaceFeatures + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.SpaceFeatures +
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
          let response = resp.data as Api.SpaceFeatureClientResponseModel;

          console.log(response);

          let mapper = new SpaceFeatureMapper();

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
            loaded: false,
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
      return <LoadingForm />;
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
									 <div>
							<div>name</div>
							<div>{this.state.model!.name}</div>
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

export const WrappedSpaceFeatureDetailComponent = Form.create({ name: 'SpaceFeature Detail' })(
  SpaceFeatureDetailComponent
);

/*<Codenesium>
    <Hash>2262ee7ca0b4eba29dd41aed88cec6b1</Hash>
</Codenesium>*/