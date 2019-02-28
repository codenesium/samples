import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import ProvinceMapper from './provinceMapper';
import ProvinceViewModel from './provinceViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {CityTableComponent} from '../shared/cityTable'
	import {VenueTableComponent} from '../shared/venueTable'
	



interface ProvinceDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface ProvinceDetailComponentState {
  model?: ProvinceViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class ProvinceDetailComponent extends React.Component<
ProvinceDetailComponentProps,
ProvinceDetailComponentState
> {
  state = {
    model: new ProvinceViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Provinces + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Provinces +
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
          let response = resp.data as Api.ProvinceClientResponseModel;

          console.log(response);

          let mapper = new ProvinceMapper();

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
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>Cities</h3>
            <CityTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Provinces + '/' + this.state.model!.id + '/' + ApiRoutes.Cities}
			/>
         </div>
			 <div>
            <h3>Venues</h3>
            <VenueTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Provinces + '/' + this.state.model!.id + '/' + ApiRoutes.Venues}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedProvinceDetailComponent = Form.create({ name: 'Province Detail' })(
  ProvinceDetailComponent
);

/*<Codenesium>
    <Hash>1ecd2c1ef3f956e7b678d455463af62e</Hash>
</Codenesium>*/